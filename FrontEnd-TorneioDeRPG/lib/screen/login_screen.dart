import 'package:flutter/material.dart';

import 'package:flutter/material.dart';
import 'package:torneio/model/login_request.dart';
import 'package:torneio/services/auth_service.dart';

class LoginScreen extends StatelessWidget {
  @override
  final _emailController = TextEditingController();
  final _passController = TextEditingController();
  final _authService = AuthService();

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: LayoutBuilder(
        builder: (context, constraint) => SingleChildScrollView(
          child: ConstrainedBox(
            constraints: BoxConstraints(minHeight: constraint.maxHeight),
            child: IntrinsicHeight(
              child: Container(
                decoration: BoxDecoration(
                  image: DecorationImage(
                    image: AssetImage("assets/plano-fundo-um.jpeg"),
                    fit: BoxFit.cover,
                  ),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(top: 60.0, bottom: 20),
                      child: Center(
                        child: Container(
                          child: Column(
                            children: [
                              Icon(
                                Icons.account_circle,
                                color: Colors.grey,
                                size: 82,
                              ),
                              Text(
                                'Torneio Universal',
                                style: TextStyle(
                                  fontSize: 24,
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                    Container(
                      width: 300,
                      height: 500,
                      child: Form(
                        key: _formKey,
                        child: Column(
                          children: [
                            Padding(
                              padding: EdgeInsets.symmetric(horizontal: 20),
                              child: TextFormField(
                                controller: _emailController,
                                keyboardType: TextInputType.emailAddress,
                                textInputAction: TextInputAction.next,
                                decoration: InputDecoration(
                                  labelText: 'Email',
                                  fillColor:
                                      Theme.of(context).colorScheme.secondary,
                                  border: OutlineInputBorder(),
                                  labelStyle: TextStyle(
                                    color: Colors.black38,
                                    fontWeight: FontWeight.w400,
                                    fontSize: 18.0,
                                  ),
                                ),
                                style: TextStyle(fontSize: 18.0),
                                validator: (value) {
                                  if (value!.isEmpty) {
                                    return 'Insira um email';
                                  }
                                  if (!RegExp(
                                          "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+.[a-z]")
                                      .hasMatch(value)) {
                                    return 'Insira um email válido';
                                  }
                                  return null;
                                },
                              ),
                            ),
                            Padding(
                              padding: const EdgeInsets.only(
                                  left: 20.0, right: 20.0, top: 15, bottom: 0),
                              child: TextFormField(
                                controller: _passController,
                                keyboardType: TextInputType.text,
                                textInputAction: TextInputAction.done,
                                obscureText: true,
                                decoration: InputDecoration(
                                  labelText: 'Senha',
                                  border: OutlineInputBorder(),
                                  labelStyle: TextStyle(
                                    color: Colors.black38,
                                    fontWeight: FontWeight.w400,
                                    fontSize: 18.0,
                                  ),
                                ),
                                style: TextStyle(fontSize: 18.0),
                                validator: (value) {
                                  if (value!.isEmpty) {
                                    return 'Insira uma senha';
                                  }
                                  return null;
                                },
                                // onFieldSubmitted: (v) => login(),
                              ),
                            ),
                            SizedBox(
                              height: 20,
                            ),
                            const SizedBox(
                              height: 30,
                            ),
                            SizedBox(
                              width: MediaQuery.of(context).size.width - 40,
                              child: ElevatedButton(
                                onPressed: () {
                                  _onLogin(context);
                                },
                                child: Text(
                                  'ENTRAR',
                                  style: TextStyle(color: Colors.white),
                                ),
                                style: ButtonStyle(
                                  backgroundColor:
                                      MaterialStateProperty.all<Color>(
                                          Color(0xFF1AC0DD)),
                                  elevation: MaterialStateProperty.all(0.0),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  _onLogin(BuildContext context) async {
    final email = _emailController.text;
    final senha = _passController.text;

    print("Email: $email , Senha: $senha ");

    if (_formKey.currentState!.validate()) {
      var login = LoginRequest(email: email, senha: senha);
      await _authService
          .login(login)
          .then((value) => Navigator.pushNamed(context, '/painel'))
          .catchError(() => _errorMessage(context));
    }

    if (email.isEmpty || senha.isEmpty) {
      _errorMessage(context);
    }
  }

  Future<dynamic> _errorMessage(BuildContext context) {
    return showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
            title: Text("Erro"),
            content: Text("Login e/ou Senha invalido(s)"),
            actions: <Widget>[
              ElevatedButton(
                  child: Text("OK"),
                  onPressed: () {
                    Navigator.pop(context);
                  })
            ]);
      },
    );
  }
}
