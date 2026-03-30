#include <iostream>
#include <string>
#include <sstream>
#include <cstdlib>
#include <ctime>

using namespace std;

// Substitui to_string
string intToStr(int n) {
    stringstream ss;
    ss << n;
    return ss.str();
}

// Substitui stoi
int strToInt(string s) {
    int n;
    stringstream ss(s);
    ss >> n;
    return n;
}

int main() {
    // Inicializa baralho
    string baralho[2][52];
    for (int n = 0; n < 2; n++) {
        int idx = 0;
        for (int naipe = 1; naipe <= 4; naipe++) {
            for (int carta = 1; carta <= 13; carta++) {
                string naipe_str  = intToStr(naipe);
                string carta_str  = (carta < 10 ? "0" : "") + intToStr(carta);
                string baralho_str = intToStr(n + 1);
                baralho[n][idx++] = naipe_str + carta_str + baralho_str;
            }
        }
    }

    // Junta os 2 baralhos em um array linear de 104 cartas
    string monte[104];
    for (int i = 0; i < 52; i++) monte[i]      = baralho[0][i];
    for (int i = 0; i < 52; i++) monte[52 + i] = baralho[1][i];

    // Embaralha (Fisher-Yates)
    srand((unsigned)time(0));
    for (int i = 103; i > 0; i--) {
        int j = rand() % (i + 1);
        swap(monte[i], monte[j]);
    }

    // Distribui 11 cartas para cada um dos 4 jogadores
    string mao[4][11];
    int idx = 0;
    for (int c = 0; c < 11; c++)
        for (int j = 0; j < 4; j++)
            mao[j][c] = monte[idx++];

    // Exibe as maos
    string naipes[]  = {"", "Copas", "Paus", "Ouro", "Espada"};
    string numeros[] = {"", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

    for (int j = 0; j < 4; j++) {
        cout << "\n=== Jogador " << (j + 1) << " ===\n";
        for (int c = 0; c < 11; c++) {
            string carta = mao[j][c];
            int naipe  = carta[0] - '0';
            int numero = strToInt(carta.substr(1, 2));
            int bar    = carta[3] - '0';
            cout << "  [" << carta << "]  "
                 << numeros[numero] << " de " << naipes[naipe]
                 << " (Baralho " << bar << ")\n";
        }
    }

    return 0;
}