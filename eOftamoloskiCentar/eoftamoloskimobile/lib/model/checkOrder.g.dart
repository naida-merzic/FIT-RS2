// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'checkOrder.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Racun _$RacunFromJson(Map<String, dynamic> json) => Racun()
  ..racunId = json['racunId'] as int?
  ..brojRacuna = json['brojRacuna'] as int?
  ..datum =
      json['datum'] == null ? null : DateTime.parse(json['datum'] as String)
  ..iznos = (json['iznos'] as num?)?.toDouble()
  ..klijentId = json['klijentId'] as int?
  ..klijent = json['klijent'] == null
      ? null
      : Klijent.fromJson(json['klijent'] as Map<String, dynamic>)
  ..stavkaRacunas = (json['stavkaRacunas'] as List<dynamic>?)
      ?.map((e) => StavkaRacuna.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$RacunToJson(Racun instance) => <String, dynamic>{
      'racunId': instance.racunId,
      'brojRacuna': instance.brojRacuna,
      'datum': instance.datum?.toIso8601String(),
      'iznos': instance.iznos,
      'klijentId': instance.klijentId,
      'klijent': instance.klijent,
      'stavkaRacunas': instance.stavkaRacunas,
    };
