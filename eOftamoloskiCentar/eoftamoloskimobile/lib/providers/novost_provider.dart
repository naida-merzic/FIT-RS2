import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../model/novost.dart';

class NovostProvider extends BaseProvider<Novost> {
  NovostProvider() : super("Novost");

  @override
  Novost fromJson(data) {
    return Novost.fromJson(data);
  }
}
