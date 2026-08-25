#include <iostream>
using namespace std;

struct No {
    int dado;
    No *prox;
};

struct Fila {
    No *ini;
    No *fim;
};

Fila* init() {
    Fila *f = new Fila;
    f->ini = NULL;
    f->fim = NULL;
    return f;
}

int isEmpty(Fila *f) {
    return (f->ini == NULL);
}

int count(Fila *f) {
    int k = 0;
    No *no = f->ini;

    while (no != NULL) {
        k++;
        no = no->prox;
    }

    return k;
}

void enqueue(Fila *f, int v) {
    No *no = new No;
    no->dado = v;
    no->prox = NULL;

    if (isEmpty(f)) {
        f->ini = no;
    }
    else {
        f->fim->prox = no;
    }

    f->fim = no;
}

int dequeue(Fila *f) {
    if (isEmpty(f))
        return -1;

    No *no = f->ini;
    int valor = no->dado;

    f->ini = no->prox;

    if (f->ini == NULL)
        f->fim = NULL;

    delete no;

    return valor;
}

int main() {

    Fila *senhasGeradas = init();
    Fila *senhasAtendidas = init();

    int opcao;
    int senhaAtual = 0;

    do {

        cout << "\n================================";
        cout << "\nSenhas aguardando atendimento: "
             << count(senhasGeradas);
        cout << "\n================================";
        cout << "\n0 - Sair";
        cout << "\n1 - Gerar senha";
        cout << "\n2 - Realizar atendimento";
        cout << "\nOpcao: ";
        cin >> opcao;

        switch(opcao) {

            case 1:
                senhaAtual++;
                enqueue(senhasGeradas, senhaAtual);

                cout << "\nSenha gerada: "
                     << senhaAtual << endl;
                break;

            case 2:

                if(isEmpty(senhasGeradas)) {
                    cout << "\nNao existem senhas aguardando atendimento.\n";
                }
                else {

                    int senha = dequeue(senhasGeradas);

                    cout << "\nAtendendo senha: "
                         << senha << endl;

                    enqueue(senhasAtendidas, senha);
                }

                break;

            case 0:

                if(!isEmpty(senhasGeradas)) {
                    cout << "\nAinda existem "
                         << count(senhasGeradas)
                         << " senha(s) aguardando atendimento.\n";
                    opcao = -1;
                }

                break;

            default:
                cout << "\nOpcao invalida.\n";
        }

    } while(opcao != 0);

    cout << "\nPrograma encerrado.";
    cout << "\nTotal de senhas atendidas: "
         << count(senhasAtendidas) << endl;

    return 0;
}