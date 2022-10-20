import 'package:eoftamoloskimobile/providers/base_provider.dart';

import '../model/checkOrder.dart';

class CheckOrderProvider extends BaseProvider<CheckOrder> {
  CheckOrderProvider() : super("Racun");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return CheckOrder();
  }
}
