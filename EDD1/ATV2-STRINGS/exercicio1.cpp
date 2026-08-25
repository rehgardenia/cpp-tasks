#include <iostream>
#include <string>
#include <thread> // Para o sleep
#include <chrono> // Para medir o tempo

using namespace std;

void exercicio1() {
    string msg;
    cout << "Digite a mensagem: ";
    getline(cin >> ws, msg);

    int linhaFinal = 20;
    string espacos((80 - msg.length()) / 2, ' ');

    for (int l = 5; l <= linhaFinal; ++l) {
        // Limpa o console (Windows)
        system("cls"); 
        
        // Pula as linhas até a posição atual
        for (int i = 0; i < l; ++i) cout << "\n";
        
        cout << espacos << msg << endl;
        
        // Pausa de 150 milissegundos
        this_thread::sleep_for(chrono::milliseconds(150));
    }
}