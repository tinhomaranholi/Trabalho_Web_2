import 'dart:convert';

class LoginRequest {
  final String email;
  final String senha;

  LoginRequest({
    required this.email,
    required this.senha,
  });

  LoginRequest copyWith({
    String? email,
    String? senha,
  }) {
    return LoginRequest(
      email: email ?? this.email,
      senha: senha ?? this.senha,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'email': email,
      'senha': senha,
    };
  }

  factory LoginRequest.fromMap(Map<String, dynamic> map) {
    return LoginRequest(
      email: map['email'],
      senha: map['senha'],
    );
  }

  String toJson() => json.encode(toMap());

  factory LoginRequest.fromJson(String source) =>
      LoginRequest.fromMap(json.decode(source));

  @override
  String toString() => 'LoginRequest(email: $email, senha: $senha)';

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;

    return other is LoginRequest &&
        other.email == email &&
        other.senha == senha;
  }

  @override
  int get hashCode => email.hashCode ^ senha.hashCode;
}
