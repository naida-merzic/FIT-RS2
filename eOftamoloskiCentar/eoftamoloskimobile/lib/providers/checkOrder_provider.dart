import 'package:eoftamoloskimobile/providers/base_provider.dart';

import '../model/checkOrder.dart';

class CheckOrderProvider extends BaseProvider<Racun> {
  CheckOrderProvider() : super("Racun");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Racun.fromJson(data);
  }
}
