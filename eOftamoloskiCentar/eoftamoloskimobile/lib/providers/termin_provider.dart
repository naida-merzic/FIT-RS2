import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/model/termin.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../model/novost.dart';

class TerminProvider extends BaseProvider<Termin> {
  TerminProvider() : super("Termin");

  @override
  Termin fromJson(data) {
    return Termin.fromJson(data);
  }
}
