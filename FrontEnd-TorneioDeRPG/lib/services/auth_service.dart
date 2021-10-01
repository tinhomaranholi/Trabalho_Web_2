import 'dart:convert';

import 'package:dio/dio.dart';
import 'package:dio/native_imp.dart';

import 'package:torneio/model/login_request.dart';
import 'package:torneio/model/login_response.dart';
import 'package:torneio/repositories/auth_repository.dart';

class AuthService {
  final AuthRepository _authRepository = AuthRepository();

  Future<LoginResponse> login(LoginRequest login) async {
    var response = await _authRepository.login(login.email, login.senha);

    return response;
  }
}
