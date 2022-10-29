import 'dart:core';
import 'package:eoftamoloskimobile/main.dart';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/model/stavkaRacuna.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:webview_flutter/webview_flutter.dart';
import 'dart:io';

import '../../providers/payment_provider.dart';

class Payment extends StatefulWidget {
  static const String routeName = "/payment";

  final Function onFinish;
  final List<StavkaRacuna> stavke;
  Payment({required this.onFinish, required this.stavke});
  @override
  State<StatefulWidget> createState() {
    return PaymentState();
  }
}

class PaymentState extends State<Payment> {
  GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();
  late String checkoutUrl = "";
  late String executeUrl = "";
  late String accessToken = "";
  PaymentService service = PaymentService();
  ProductProvider? _productProvider = null;
  List items = [];
  String totalAmount = '0';
  String subTotalAmount = '0';

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
        final transactions = getOrderParams();
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

  getArtikalById(int id) async {
    List<Product>? artikal = await _productProvider?.get(id);
    return artikal!.first;
  }

  // you can change default currency according to your need
  Map<dynamic, dynamic> defaultCurrency = {
    "symbol": "EUR",
    "decimalDigits": 2,
    "symbolBeforeTheNumber": true,
    "currency": "EUR"
  };
  bool isEnableShipping = false;
  bool isEnableAddress = false;
  String returnURL = 'return.example.com';
  String cancelURL = 'cancel.example.com';

  getInitialValues() async {
    items = [
      for (var stavka in widget.stavke)
        {
          "name": (await getArtikalById(stavka.artikalId!) as Product).naziv,
          "quantity": stavka.kolicina,
          "price": (await getArtikalById(stavka.artikalId!) as Product).cijena!,
          "currency": defaultCurrency["currency"]
        }
    ];
    double total = 0;
    for (var stavka in widget.stavke) {
      total += (await getArtikalById(stavka.artikalId!) as Product).cijena! *
          stavka.kolicina!;
    }
    totalAmount = subTotalAmount = total.toString();
  }

  Map<String, dynamic> getOrderParams() {
    // checkout invoice details
    String shippingCost = '0';
    int shippingDiscountCost = 0;
    // String userFirstName = HttpService.klijent.ime!;
    // String userLastName = HttpService.klijent.prezime!;
    // String addressCity = HttpService.klijent.gradId.toString();
    // String addressStreet = HttpService.klijent.adresa!;
    // String addressZipCode = HttpService.klijent.adresa!;
    // String addressCountry = 'Bosnia and Herzegowina';
    // String addressState = HttpService.klijent.adresa!;
    // String addressPhoneNumber = HttpService.klijent.telefon!;
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
                // "recipient_name": userFirstName + " " + userLastName,
                // "line1": addressStreet,
                // "line2": "",
                // "city": addressCity,
                // "country_code": addressCountry,
                // "postal_code": addressZipCode,
                // "phone": addressPhoneNumber,
                // "state": addressState
              },
          }
        }
      ],
      "note_to_payer": "Kontaktirajte nas za bilo kakva pitanja.",
      "redirect_urls": {"return_url": returnURL, "cancel_url": cancelURL}
    };
    return temp;
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
                  content: Text("Uspješna transakcija."),
                ));
                Navigator.of(context)
                    .push(MaterialPageRoute(builder: (context) => HomePage()));
              } else {
                ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
                  backgroundColor: Colors.redAccent,
                  duration: Duration(milliseconds: 1000),
                  content: Text(
                      "Greška prilikom plaćanja, pokušajte ponovo kasnije."),
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
        key: _scaffoldKey,
        appBar: AppBar(
          leading: IconButton(
              icon: Icon(Icons.arrow_back),
              onPressed: () {
                Navigator.of(context).pop();
              }),
          backgroundColor: Colors.black12,
          elevation: 0.0,
        ),
        body: Center(child: Container(child: CircularProgressIndicator())),
      );
    }
  }
}
