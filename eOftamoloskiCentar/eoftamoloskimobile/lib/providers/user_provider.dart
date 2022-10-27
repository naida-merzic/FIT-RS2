import 'package:eoftamoloskimobile/model/klijent.dart';

import '../model/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<Klijent> {
  UserProvider() : super("Klijent");

  @override
  Klijent fromJson(data) {
    // TODO: implement fromJson
    return Klijent();
  }
}
