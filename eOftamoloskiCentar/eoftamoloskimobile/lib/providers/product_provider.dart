import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/product.dart';
//import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class ProductProvider with ChangeNotifier {
  HttpClient client = new HttpClient();
  IOClient? http;
  ProductProvider() {
    print("called ProductProvider");
    client.badCertificateCallback = (cert, host, port) => true;
    //need to check  actually
    http = IOClient(client);
  }

  Future<List<Product>> get(dynamic searchObject) async {
    print("called provider.GET METHOD");
    var url = Uri.parse("https://10.0.2.2:7031/Artikli");

    String username = "admin";
    String password = "test";

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    var response = await http!.get(url, headers: headers);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<Product> list =
          data.map((x) => Product.fromJson(x)).cast<Product>().toList();
      return list;
    } else {
      throw Exception("User not allowed!");
    }
  }
}
