#include <iostream>
#include <vector>
#include <string>
#include <iomanip>

using namespace std;

struct Funcionario {
    int prontuario;
    string nome;
    double salario;
};

// Função para buscar índice pelo prontuário
int buscarFuncionario(const vector<Funcionario>& lista, int prontuario) {
    for (size_t i = 0; i < lista.size(); i++) {
        if (lista[i].prontuario == prontuario) {
            return i;
        }
    }
    return -1;
}

void incluir(vector<Funcionario>& lista) {
    Funcionario f;

    cout << "Digite o prontuario: ";
    cin >> f.prontuario;

    // Verifica duplicidade
    if (buscarFuncionario(lista, f.prontuario) != -1) {
        cout << "Erro: prontuario ja existente!\n";
        return;
    }

    cout << "Digite o nome: ";
    cin.ignore();
    getline(cin, f.nome);

    cout << "Digite o salario: ";
    cin >> f.salario;

    lista.push_back(f);
    cout << "Funcionario incluído com sucesso!\n";
}

void excluir(vector<Funcionario>& lista) {
    int prontuario;
    cout << "Digite o prontuario a excluir: ";
    cin >> prontuario;

    int pos = buscarFuncionario(lista, prontuario);

    if (pos == -1) {
        cout << "Funcionario nao encontrado!\n";
    } else {
        lista.erase(lista.begin() + pos);
        cout << "Funcionario excluido com sucesso!\n";
    }
}

void pesquisar(const vector<Funcionario>& lista) {
    int prontuario;
    cout << "Digite o prontuario a pesquisar: ";
    cin >> prontuario;

    int pos = buscarFuncionario(lista, prontuario);

    if (pos == -1) {
        cout << "Funcionario nao encontrado!\n";
    } else {
        cout << "\nFuncionario encontrado:\n";
        cout << "Prontuario: " << lista[pos].prontuario << endl;
        cout << "Nome: " << lista[pos].nome << endl;
        cout << "Salario: R$ " << fixed << setprecision(2) << lista[pos].salario << endl;
    }
}

void listar(const vector<Funcionario>& lista) {
    double totalSalarios = 0;

    if (lista.empty()) {
        cout << "Nenhum funcionario cadastrado.\n";
        return;
    }

    cout << "\nLista de Funcionarios:\n";
    cout << "-----------------------------\n";

    for (const auto& f : lista) {
        cout << "Prontuario: " << f.prontuario << endl;
        cout << "Nome: " << f.nome << endl;
        cout << "Salario: R$ " << fixed << setprecision(2) << f.salario << endl;
        cout << "-----------------------------\n";
        totalSalarios += f.salario;
    }

    cout << "Total dos salarios: R$ " << fixed << setprecision(2) << totalSalarios << endl;
}

int main() {
    vector<Funcionario> lista;
    int opcao;

    do { 
        cout << "\n-------------------------\n";
        cout << " GESTÃO DE FUNCIONÁRIOS";
        cout << "\n-------------------------\n";
        cout << "0. Sair\n";
        cout << "1. Incluir\n";
        cout << "2. Excluir\n";
        cout << "3. Pesquisar\n";
        cout << "4. Listar\n";
        cout << "-------------------------\n";
        cout << "Escolha uma opcao: ";
        cin >> opcao;

        switch (opcao) {
            case 1:
                incluir(lista);
                break;
            case 2:
                excluir(lista);
                break;
            case 3:
                pesquisar(lista);
                break;
            case 4:
                listar(lista);
                break;
            case 0:
                cout << "Encerrando...\n";
                break;
            default:
                cout << "Opcao invalida!\n";
        }

    } while (opcao != 0);

    return 0;
}