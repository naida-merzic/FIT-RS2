// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product()
  ..artikalId = json['artikalId'] as int?
  ..naziv = json['naziv'] as String?
  ..slika = json['slika'] as String?
  ..opis = json['opis'] as String?
  ..cijena = (json['cijena'] as num?)?.toDouble();

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'artikalId': instance.artikalId,
      'naziv': instance.naziv,
      'slika': instance.slika,
      'opis': instance.opis,
      'cijena': instance.cijena,
    };
