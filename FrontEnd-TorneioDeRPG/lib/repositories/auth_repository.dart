import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:dio/native_imp.dart';
import 'package:torneio/model/login_request.dart';
import 'package:torneio/model/login_response.dart';

class AuthRepository {
  AuthRepository();

  @override
  Future<LoginResponse> login(String email, String senha) async {
    try {
      var body = {
        'email': email,
        'senha': senha,
      };

      var response = await Dio()
          .post('http://192.168.20.11:5000/api/Auth/login', data: body);

      var result = LoginResponse.fromJson(response.data);
      return result;
    } on DioError catch (err) {
      return err.response!.data;
    }
  }
}
