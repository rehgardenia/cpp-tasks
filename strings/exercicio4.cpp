#include <sstream>

void formatoCitacao() {
    ifstream arquivo("nomes.txt");
    string linha;

    while (getline(arquivo, linha)) {
        stringstream ss(linha);
        string palavra;
        vector<string> partes;

        while (ss >> palavra) partes.push_back(palavra);

        if (partes.size() >= 2) {
            // Último nome em MAIÚSCULAS
            string ultimo = partes.back();
            for (char &c : ultimo) c = toupper(c);
            
            cout << ultimo << ", " << partes[0];

            // Iniciais do meio
            for (size_t i = 1; i < partes.size() - 1; ++i) {
                if (partes[i].length() > 2) { // Ignora "de", "da"
                    cout << " " << (char)toupper(partes[i][0]) << ".";
                }
            }
            cout << endl;
        }
    }
}