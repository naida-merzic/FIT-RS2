// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product()
  ..artikalId = json['artikalId'] as int?
  ..naziv = json['naziv'] as String?
  ..slika = json['slika'] as String?;

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'artikalId': instance.artikalId,
      'naziv': instance.naziv,
      'slika': instance.slika,
    };
