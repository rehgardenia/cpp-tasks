#include <iostream>
#include <locale.h>
#include <string>

using namespace std;

// --- CLASSE DATA ---
class Data 
{
    private:
        int dia;
        int mes;
        int ano;
        
    public:
        // Construtores
        Data(int dia, int mes, int ano) {
            this->dia = dia;
            this->mes = mes;
            this->ano = ano;
        }
        Data() {
            this->dia = 0;
            this->mes = 0;
            this->ano = 0;
        }

        // Getters e Setters
        void setDia(int dia) { this->dia = dia; }
        void setMes(int mes) { this->mes = mes; }
        void setAno(int ano) { this->ano = ano; }
        
        int getDia() { return this->dia; }
        int getMes() { return this->mes; }
        int getAno() { return this->ano; }

        string getData() {
            string sdia = to_string(this->dia);
            string smes = to_string(this->mes);
            string sano = to_string(this->ano);
            return (sdia.size() < 2 ? "0" + sdia : sdia) + "/" + 
                   (smes.size() < 2 ? "0" + smes : smes) + "/" + 
                   sano;
        }
};

// --- CLASSE CONTATO ---
class Contato {
    private:
        string email;
        string nome;
        string telefone;
        Data dtNasc;

    public:
        // Construtores
        Contato(string e, string nm, string tel, Data dt) {
            this->email = e;
            this->nome = nm;
            this->telefone = tel;
            this->dtNasc = dt;
        }
        Contato() {}

        // Setters
        void setEmail(string e) { this->email = e; }
        void setNome(string n) { this->nome = n; }
        void setTelefone(string tel) { this->telefone = tel; }
        void setDtNasc(Data dt) { this->dtNasc = dt; }

        // Getters
        string getEmail() { return this->email; }
        string getNome() { return this->nome; }
        string getTelefone() { return this->telefone; }
        Data getDtNasc() { return this->dtNasc; }

        // M�todo para calcular idade baseado no ano de 2026
        int idade() {
            return 2026 - this-> dtNasc.getAno();
        }

        // M�todo para exibi��o formatada
        void exibirContato() {
            cout << "Nome:     " << this->nome << endl;
            cout << "E-mail:   " << this->email << endl;
            cout << "Telefone: " << this->telefone << endl;
            cout << "Nasc.:    " << this->dtNasc.getData() << endl;
            cout << "Idade:    " << this->idade() << " anos" << endl;
            cout << "--------------------------" << endl;
        }
};

// --- PROGRAMA PRINCIPAL ---
int main() {
    setlocale(LC_ALL, "");
    
    Contato contatos[5];
    string nome, email, telefone;
    int d, m, a;

    cout << "### CADASTRO DE 5 CONTATOS ###" << endl;

    for(int i = 0; i < 5; i++) {

        cout << "\n--- Dados do " << i + 1 << "� Contato ---" << endl;
        
        // Limpar o buffer do teclado antes de ler strings
        cin.ignore(); 
        
        cout << "Nome completo: ";
        getline(cin, nome);
        
        cout << "E-mail: ";
        cin >> email;
        
        cout << "Telefone: ";
        cin >> telefone;
        
        cout << "Data de Nasc. (dia mes ano): ";
        cin >> d >> m >> a;

        // Armazenando o objeto no vetor
        contatos[i] = Contato(email, nome, telefone, Data(d, m, a));
    }

    cout << "\n\n### LISTA DE CONTATOS CADASTRADOS ###" << endl;
    cout << "--------------------------" << endl;
    for(int i = 0; i < 5; i++) {
        contatos[i].exibirContato();
    }

    return 0;
}