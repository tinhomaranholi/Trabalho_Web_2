import 'package:flutter/material.dart';
import 'package:torneio/screen/login_screen.dart';
import 'package:torneio/screen/painel_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.amber,
      ),
      routes: {
        '/': (context) => LoginScreen(),
        '/painel': (context) => PainelScreen(),
        // '/home': (context) => MyHomePage(title: 'Login Demo'),
      },
      // home: LoginScreen(),
    );
  }
}
