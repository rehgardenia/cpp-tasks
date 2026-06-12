#include <iostream>
#include <limits>
using namespace std;

// ──────────────────────────────────────────────
//  Leitura segura de inteiro
// ──────────────────────────────────────────────

int lerInt(const string &prompt) {
    int valor;
    while (true) {
        cout << prompt;
        cin >> valor;

        if (cin.good()) {
            return valor;           // leitura válida
        }

        // entrada inválida (letra, símbolo, etc.)
        cin.clear();                // limpa flag de erro
        cin.ignore(numeric_limits<streamsize>::max(), '\n'); // descarta o lixo do buffer
        cout << "Entrada invalida! Digite apenas numeros inteiros.\n";
    }
}

// ──────────────────────────────────────────────
//  Estruturas da Fila
// ──────────────────────────────────────────────

struct No {
    int dado;
    No *prox;
};

struct Fila {
    No *ini;
    No *fim;
};

Fila* initFila() {
    Fila *f = new Fila;
    f->ini = NULL;
    f->fim = NULL;
    return f;
}

int isEmpty(Fila *f) {
    return (f->ini == NULL);
}

int countFila(Fila *f) {
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

    if (isEmpty(f))
        f->ini = no;
    else
        f->fim->prox = no;

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

// ──────────────────────────────────────────────
//  Estruturas da Lista de Guichês
// ──────────────────────────────────────────────

struct Guiche {
    int id;
    Fila *senhasAtendidas;
};

struct NoLista {
    Guiche *guiche;
    NoLista *prox;
};

struct Lista {
    NoLista *ini;
};

Lista* initLista() {
    Lista *l = new Lista;
    l->ini = NULL;
    return l;
}

int isListaEmpty(Lista *l) {
    return (l->ini == NULL);
}

int countLista(Lista *l) {
    int k = 0;
    NoLista *no = l->ini;
    while (no != NULL) {
        k++;
        no = no->prox;
    }
    return k;
}

// Retorna ponteiro para o guichê com o id informado, ou NULL se não encontrar
Guiche* buscarGuiche(Lista *l, int id) {
    NoLista *no = l->ini;
    while (no != NULL) {
        if (no->guiche->id == id)
            return no->guiche;
        no = no->prox;
    }
    return NULL;
}

// Verifica se já existe um guichê com esse id
int guicheExiste(Lista *l, int id) {
    return (buscarGuiche(l, id) != NULL);
}

void adicionarGuiche(Lista *l, int id) {
    Guiche *g = new Guiche;
    g->id = id;
    g->senhasAtendidas = initFila();

    NoLista *no = new NoLista;
    no->guiche = g;
    no->prox = NULL;

    // Insere no fim da lista
    if (isListaEmpty(l)) {
        l->ini = no;
    } else {
        NoLista *atual = l->ini;
        while (atual->prox != NULL)
            atual = atual->prox;
        atual->prox = no;
    }
}

// Conta o total de senhas atendidas em todos os guichês
int totalAtendidas(Lista *l) {
    int total = 0;
    NoLista *no = l->ini;
    while (no != NULL) {
        total += countFila(no->guiche->senhasAtendidas);
        no = no->prox;
    }
    return total;
}

// ──────────────────────────────────────────────
//  main
// ──────────────────────────────────────────────

int main() {

    Fila  *senhasGeradas = initFila();
    Lista *guiches       = initLista();

    int opcao;
    int senhaAtual = 0;

    do {
        cout << "\n========================================";
        cout << "\nSenhas aguardando atendimento : " << countFila(senhasGeradas);
        cout << "\nGuiches abertos               : " << countLista(guiches);
        cout << "\n========================================";
        cout << "\n0 - Sair";
        cout << "\n1 - Gerar senha";
        cout << "\n2 - Abrir guiche";
        cout << "\n3 - Realizar atendimento";
        cout << "\n4 - Listar senhas atendidas";
        opcao = lerInt("\nOpcao: ");

        switch (opcao) {

            // ── Gerar senha ──────────────────────────
            case 1:
                senhaAtual++;
                enqueue(senhasGeradas, senhaAtual);
                cout << "\nSenha gerada: " << senhaAtual << endl;
                break;

            // ── Abrir guiche ─────────────────────────
            case 2: {
                int idGuiche = lerInt("\nInforme o id do novo guiche: ");

                if (guicheExiste(guiches, idGuiche)) {
                    cout << "\nGuiche " << idGuiche << " ja esta aberto.\n";
                } else {
                    adicionarGuiche(guiches, idGuiche);
                    cout << "\nGuiche " << idGuiche << " aberto com sucesso.\n";
                }
                break;
            }

            // ── Realizar atendimento ─────────────────
            case 3: {
                if (isEmpty(senhasGeradas)) {
                    cout << "\nNao existem senhas aguardando atendimento.\n";
                    break;
                }
                if (isListaEmpty(guiches)) {
                    cout << "\nNenhum guiche aberto. Abra um guiche primeiro (opcao 2).\n";
                    break;
                }

                int idGuiche = lerInt("\nInforme o id do guiche que esta chamando: ");

                Guiche *g = buscarGuiche(guiches, idGuiche);
                if (g == NULL) {
                    cout << "\nGuiche " << idGuiche << " nao encontrado.\n";
                } else {
                    int senha = dequeue(senhasGeradas);
                    enqueue(g->senhasAtendidas, senha);
                    cout << "\nGuiche " << idGuiche
                         << " atendendo senha: " << senha << endl;
                }
                break;
            }

            // ── Listar senhas atendidas ───────────────
            case 4: {
                if (isListaEmpty(guiches)) {
                    cout << "\nNenhum guiche aberto.\n";
                    break;
                }

                int idGuiche = lerInt("\nInforme o id do guiche: ");

                Guiche *g = buscarGuiche(guiches, idGuiche);
                if (g == NULL) {
                    cout << "\nGuiche " << idGuiche << " nao encontrado.\n";
                } else {
                    int qtd = countFila(g->senhasAtendidas);
                    cout << "\nGuiche " << idGuiche
                         << " - Senhas atendidas (" << qtd << "):";

                    if (qtd == 0) {
                        cout << " nenhuma senha atendida ainda.";
                    } else {
                        No *no = g->senhasAtendidas->ini;
                        while (no != NULL) {
                            cout << " " << no->dado;
                            no = no->prox;
                        }
                    }
                    cout << endl;
                }
                break;
            }

            // ── Sair ─────────────────────────────────
            case 0:
                if (!isEmpty(senhasGeradas)) {
                    cout << "\nAinda existem "
                         << countFila(senhasGeradas)
                         << " senha(s) aguardando atendimento. "
                         << "Encerre os atendimentos antes de sair.\n";
                    opcao = -1;   // impede saída
                }
                break;

            default:
                cout << "\nOpcao invalida.\n";
        }

    } while (opcao != 0);

    cout << "\nPrograma encerrado.";
    cout << "\nTotal de senhas atendidas: " << totalAtendidas(guiches) << endl;

    return 0;
}
