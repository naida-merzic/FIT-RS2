import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/dojam.dart';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../model/novost.dart';

class DojamProvider extends BaseProvider<Dojam> {
  DojamProvider() : super("Dojam");

  @override
  Dojam fromJson(data) {
    return Dojam.fromJson(data);
  }
}
