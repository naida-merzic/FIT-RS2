import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../model/novost.dart';

class KorisnickiRacunProvider extends BaseProvider<Klijent> {
  KorisnickiRacunProvider() : super("Klijent");

  @override
  Klijent fromJson(data) {
    return Klijent.fromJson(data);
  }
}
