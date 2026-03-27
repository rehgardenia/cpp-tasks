#include <algorithm>

bool isPalindromo() {
    string msg, limpo = "";
    cout << "Digite a frase: ";
    getline(cin >> ws, msg);

    // Remove espaços e padroniza para maiúsculas
    for (char c : msg) {
        if (!isspace(c)) {
            limpo += toupper(c);
        }
    }

    string invertido = limpo;
    reverse(invertido.begin(), invertido.end());

    return limpo == invertido;
}