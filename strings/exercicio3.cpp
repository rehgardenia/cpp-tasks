#include <fstream>
#include <vector>

void formatoAgenda() {
    ifstream arquivo("nomes.txt");
    string nomeCompleto;

    if (!arquivo.is_open()) {
        cout << "Erro ao abrir o arquivo!";
        return;
    }

    while (getline(arquivo, nomeCompleto)) {
        size_t ultimoEspaco = nomeCompleto.find_last_of(" ");
        
        if (ultimoEspaco != string::npos) {
            string ultimoNome = nomeCompleto.substr(ultimoEspaco + 1);
            string resto = nomeCompleto.substr(0, ultimoEspaco);
            cout << ultimoNome << ", " << resto << endl;
        } else {
            cout << nomeCompleto << endl;
        }
    }
    arquivo.close();
}