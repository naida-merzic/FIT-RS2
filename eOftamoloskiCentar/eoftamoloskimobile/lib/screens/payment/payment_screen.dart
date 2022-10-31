import 'dart:io';

import 'package:eoftamoloskimobile/model/checkOrder.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';
import 'package:webview_flutter/webview_flutter.dart';

import '../../main.dart';
import '../../model/product.dart';
import '../../model/stavkaRacuna.dart';
import '../../providers/payment_provider.dart';
import '../../providers/product_provider.dart';

class PaymentScreen extends StatefulWidget {
  static const String routeName = "/payment";
  final Racun? racun;
  final Function onFinish;
  PaymentScreen({required this.onFinish, required this.racun, super.key});

  @override
  State<PaymentScreen> createState() => _PaymentScreenState();
}

class _PaymentScreenState extends State<PaymentScreen> {
  late String checkoutUrl = "";
  late String executeUrl = "";
  late String accessToken = "";
  PaymentService service = PaymentService();
  ProductProvider? _productProvider = null;
  List items = [];
  String totalAmount = '0';
  String subTotalAmount = '0';
  List<StavkaRacuna> stavke = [];
  bool isEnableShipping = false;
  bool isEnableAddress = false;
  String returnURL = 'return.example.com';
  String cancelURL = 'cancel.example.com';

  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    _productProvider = context.read<ProductProvider>();
    getInitialValues();

    if (Platform.isAndroid) WebView.platform = AndroidWebView();
    Future.delayed(Duration.zero, () async {
      try {
        accessToken = (await service.getAccessToken())!;
        final transactions = await getOrderParams();

        final res =
            await service.createPaypalPayment(transactions, accessToken);
        if (res != null) {
          setState(() {
            checkoutUrl = res["approvalUrl"].toString();
            executeUrl = res["executeUrl"].toString();
          });
        }
      } catch (e) {
        final snackBar = SnackBar(
          content: Text(e.toString()),
          duration: Duration(seconds: 10),
          action: SnackBarAction(
            label: 'Close',
            onPressed: () {
              // Some code to undo the change.
            },
          ),
        );
        // _scaffoldKey.currentState?.showSnackBar(snackBar);
      }
    });
  }

  Map<String, dynamic> getOrderParams() {
    // checkout invoice details
    String shippingCost = '0';
    int shippingDiscountCost = 0;
    String userFirstName = Authorization.loggedUser!.korisnickiRacun!.ime!;
    String userLastName = Authorization.loggedUser!.korisnickiRacun!.prezime!;
    String addressCity = "Mostar";
    String addressStreet = "Marsala Tita";
    String addressZipCode = "88000";
    String addressCountry = 'Bosnia and Herzegowina';
    String addressState = "HNK";
    String addressPhoneNumber =
        Authorization.loggedUser!.korisnickiRacun!.brojTelefona!;
    Map<String, dynamic> temp = {
      "intent": "sale",
      "payer": {"payment_method": "paypal"},
      "transactions": [
        {
          "amount": {
            "total": totalAmount,
            "currency": defaultCurrency["currency"],
            "details": {
              "shipping": shippingCost,
              "shipping_discount": ((-1.0) * shippingDiscountCost).toString()
            }
          },
          "description": "The payment transaction description.",
          "payment_options": {
            "allowed_payment_method": "INSTANT_FUNDING_SOURCE"
          },
          "item_list": {
            "items": items,
            if (isEnableShipping && isEnableAddress)
              "shipping_address": {
                "recipient_name": userFirstName + " " + userLastName,
                "line1": addressStreet,
                "line2": "",
                "city": addressCity,
                "country_code": addressCountry,
                "postal_code": addressZipCode,
                "phone": addressPhoneNumber,
                "state": addressState
              },
          }
        }
      ],
      "note_to_payer": "Kontaktirajte nas za bilo kakva pitanja.",
      "redirect_urls": {"return_url": returnURL, "cancel_url": cancelURL}
    };
    return temp;
  }

  Map<dynamic, dynamic> defaultCurrency = {
    "symbol": "EUR",
    "decimalDigits": 2,
    "symbolBeforeTheNumber": true,
    "currency": "EUR"
  };
  getArtikalById(int? id) async {
    List<Product>? artikal = await _productProvider?.get({'artikalId': id});
    return artikal!.first;
  }

  getInitialValues() async {
    totalAmount = subTotalAmount = widget.racun!.iznos.toString();
  }

  @override
  Widget build(BuildContext context) {
    if (checkoutUrl != "") {
      return Scaffold(
        appBar: AppBar(
          backgroundColor: Theme.of(context).backgroundColor,
          leading: GestureDetector(
            child: Icon(Icons.arrow_back_ios),
            onTap: () => Navigator.pop(context),
          ),
        ),
        body: WebView(
          initialUrl: checkoutUrl,
          javascriptMode: JavascriptMode.unrestricted,
          navigationDelegate: (NavigationRequest request) {
            if (request.url.contains(returnURL)) {
              final uri = Uri.parse(request.url);
              final payerID = uri.queryParameters['PayerID'];
              if (payerID != null) {
                service
                    .executePayment(executeUrl, payerID, accessToken)
                    .then((id) {
                  widget.onFinish(id);
                });
                ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                  backgroundColor: Colors.green,
                  duration: Duration(milliseconds: 1000),
                  content: Text("Successful transaction."),
                ));
                Navigator.of(context)
                    .push(MaterialPageRoute(builder: (context) => HomePage()));
              } else {
                ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                  backgroundColor: Colors.redAccent,
                  duration: Duration(milliseconds: 1000),
                  content: Text("Payment error, please try again later."),
                ));
              }
              Navigator.of(context).pop();
            }
            if (request.url.contains(cancelURL)) {
              Navigator.of(context).pop();
            }
            return NavigationDecision.navigate;
          },
        ),
      );
    } else {
      return Scaffold(
        appBar: AppBar(
          leading: IconButton(
              icon: Icon(Icons.arrow_back),
              onPressed: () {
                Navigator.of(context).pop();
              }),
          backgroundColor: Colors.black12,
          elevation: 0.0,
        ),
        body: Center(
            child: Container(
          child: CircularProgressIndicator(),
        )),
      );
    }
  }
}
