import 'package:flutter/material.dart';

import 'package:flutter/material.dart';

class PainelScreen extends StatelessWidget {
  @override
  final _nomeController = TextEditingController();
  final _passController = TextEditingController();

  final _formKey = GlobalKey<FormState>();
  final _scaffoldKey = GlobalKey<ScaffoldState>();

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
                    image: AssetImage("assets/pf-dois.png"),
                    fit: BoxFit.cover,
                  ),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(top: 60.0, bottom: 20),
                      child: Container(
                        width: 500,
                        height: 500,
                        decoration: BoxDecoration(
                          color: Colors.white,
                        ),
                        child: Column(
                          children: [
                            ..._cabecalho(),
                            ..._formularioUsuario(),
                            _btnAdicionar(context),
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

  SizedBox _btnAdicionar(BuildContext context) {
    return SizedBox(
      width: MediaQuery.of(context).size.width - 40,
      child: Padding(
        padding: const EdgeInsets.only(top: 4, bottom: 4),
        child: ElevatedButton(
          onPressed: () {},
          child: Text(
            'ADICIONAR',
            style: TextStyle(color: Colors.black),
          ),
          style: ButtonStyle(
            backgroundColor:
                MaterialStateProperty.all<Color>(Color(0xFF1AC0DD)),
            elevation: MaterialStateProperty.all(0.0),
          ),
        ),
      ),
    );
  }

  List<Widget> _cabecalho() {
    return [
      Padding(
        padding: const EdgeInsets.only(top: 24, bottom: 16),
        child: Text(
          'Adicione seu time',
          style: TextStyle(color: Colors.black, fontSize: 20),
        ),
      ),
      Divider(
        height: 2,
      ),
    ];
  }

  List<Widget> _formularioUsuario() {
    return [
      Align(
        alignment: Alignment.topLeft,
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: Text(
            'Dados do time',
            style: TextStyle(
                color: Colors.black, fontSize: 14, fontWeight: FontWeight.w600),
          ),
        ),
      ),
      Container(
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              TextFormField(
                controller: _nomeController,
                keyboardType: TextInputType.text,
                textInputAction: TextInputAction.next,
                decoration: InputDecoration(
                  labelText: 'Nome do time',
                  border: OutlineInputBorder(),
                  labelStyle: TextStyle(
                    color: Colors.black38,
                    fontWeight: FontWeight.w400,
                    fontSize: 14.0,
                  ),
                ),
                style: TextStyle(fontSize: 14.0),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Digite seu nome';
                  }
                  return null;
                },
              ),
            ],
          ),
        ),
      ),
      SizedBox(
        height: 20,
      ),
    ];
  }

  void cadastro() {
    if (_formKey.currentState!.validate()) {
      // var login = LoginRequest(email: email, senha: senha);
      // await _authService.login(login);
      // Navigator.pushNamed(context, '/painel');
    }
  }
}
