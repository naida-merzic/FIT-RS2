// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnickiRacun.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KorisnickiRacun _$KorisnickiRacunFromJson(Map<String, dynamic> json) =>
    KorisnickiRacun()
      ..korisnickiRacunId = json['korisnickiRacunId'] as int?
      ..ime = json['ime'] as String?
      ..prezime = json['prezime'] as String?
      ..email = json['email'] as String?
      ..brojTelefona = json['brojTelefona'] as String?
      ..adresa = json['adresa'] as String?
      ..lozinkaHash = json['lozinkaHash'] as String?
      ..lozinkaSalt = json['lozinkaSalt'] as String?
      ..korisnickoIme = json['korisnickoIme'] as String?
      ..datumRodjenja = json['datumRodjenja'] == null
          ? null
          : DateTime.parse(json['datumRodjenja'] as String);

Map<String, dynamic> _$KorisnickiRacunToJson(KorisnickiRacun instance) =>
    <String, dynamic>{
      'korisnickiRacunId': instance.korisnickiRacunId,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'brojTelefona': instance.brojTelefona,
      'adresa': instance.adresa,
      'lozinkaHash': instance.lozinkaHash,
      'lozinkaSalt': instance.lozinkaSalt,
      'korisnickoIme': instance.korisnickoIme,
      'datumRodjenja': instance.datumRodjenja?.toIso8601String(),
    };
