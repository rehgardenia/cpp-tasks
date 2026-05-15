#include <iostream>
using namespace std;


struct No {
    int valor;
    No* prox;
};

class PilhaLista {
private:
    No* topo;

public:
    PilhaLista() {
        topo = NULL;
    }

    void push(int valor) {
        No* novo = new No;
        novo->valor = valor;
        novo->prox = topo;
        topo = novo;
    }

    bool vazia() {
        return topo == NULL;
    }

    int pop() {
        if (vazia()) {
            return -1;
        }

        No* temp = topo;
        int valor = topo->valor;

        topo = topo->prox;
        delete temp;

        return valor;
    }
};


class PilhaVetor {
private:
    int topo;
    int vetor[30];

public:
    PilhaVetor() {
        topo = -1;
    }

    bool cheia() {
        return topo == 29;
    }

    bool vazia() {
        return topo == -1;
    }

    void push(int valor) {
        if (!cheia()) {
            topo++;
            vetor[topo] = valor;
        }
    }

    int pop() {
        if (!vazia()) {
            int valor = vetor[topo];
            topo--;
            return valor;
        }

        return -1;
    }
};


int main() {

    PilhaLista pilhaParLista;
    PilhaLista pilhaImparLista;

    PilhaVetor pilhaParVetor;
    PilhaVetor pilhaImparVetor;

    int numero;
    int anterior = -999999;

    cout << "Digite 30 numeros inteiros em ordem crescente:\n";

    for (int i = 0; i < 30; i++) {

        do {
            cout << "Numero " << i + 1 << ": ";
            cin >> numero;

            if (numero <= anterior) {
                cout << "ERRO! O numero deve ser maior que o anterior ("
                     << anterior << ").\n";
            }

        } while (numero <= anterior);

        anterior = numero;

        // EMPILHAR NAS PILHAS DE LISTA
        if (numero % 2 == 0) {
            pilhaParLista.push(numero);
        } else {
            pilhaImparLista.push(numero);
        }

        // EMPILHAR NAS PILHAS DE VETOR
        if (numero % 2 == 0) {
            pilhaParVetor.push(numero);
        } else {
            pilhaImparVetor.push(numero);
        }
    }


    cout << "\n========== PILHAS COM LISTA ENCADEADA ==========\n";

    cout << "\nPares em ordem decrescente:\n";
    while (!pilhaParLista.vazia()) {
        cout << pilhaParLista.pop() << " ";
    }

    cout << "\n\nImpares em ordem decrescente:\n";
    while (!pilhaImparLista.vazia()) {
        cout << pilhaImparLista.pop() << " ";
    }

 
    cout << "\n\n========== PILHAS COM VETOR ==========\n";

    cout << "\nPares em ordem decrescente:\n";
    while (!pilhaParVetor.vazia()) {
        cout << pilhaParVetor.pop() << " ";
    }

    cout << "\n\nImpares em ordem decrescente:\n";
    while (!pilhaImparVetor.vazia()) {
        cout << pilhaImparVetor.pop() << " ";
    }

    cout << endl;

    return 0;
}