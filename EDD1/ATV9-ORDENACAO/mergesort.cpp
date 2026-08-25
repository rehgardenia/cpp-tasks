#include <iostream>
using namespace std;

// Exibição
void exibir(int v[], int n) {
    for (int i = 0; i < n; i++) {
        cout << v[i] << " ";
    }
    cout << endl;
}

// Mesclar
void mesclar(int v[], int inicio, int meio, int fim) {
    int n1 = meio - inicio + 1; // subvetor esquerdo
    int n2 = fim - meio;        // subvetor direito

    int* esquerda = new int[n1];
    int* direita = new int[n2];

    for (int i = 0; i < n1; i++)
        esquerda[i] = v[inicio + i];
    for (int j = 0; j < n2; j++)
        direita[j] = v[meio + 1 + j];

    int i = 0, j = 0, k = inicio;

    // Mescla os dois subvetores de volta em v[]
    while (i < n1 && j < n2) {
        if (esquerda[i] <= direita[j]) {
            v[k] = esquerda[i];
            i++;
        } else {
            v[k] = direita[j];
            j++;
        }
        k++;
    }

    // Copia os elementos restantes, se houver
    while (i < n1) {
        v[k] = esquerda[i];
        i++;
        k++;
    }
    while (j < n2) {
        v[k] = direita[j];
        j++;
        k++;
    }

    delete[] esquerda;
    delete[] direita;
}

// Função recursiva do Merge Sort
void mergeSort(int v[], int inicio, int fim) {
    if (inicio < fim) {
        int meio = inicio + (fim - inicio) / 2;

        mergeSort(v, inicio, meio);   // ordena a metade esquerda
        mergeSort(v, meio + 1, fim);  // ordena a metade direita

        mesclar(v, inicio, meio, fim); // mescla as duas metades ordenadas
    }
}

int main() {
    int v[] = {49, 38, 58, 87, 34, 93, 26, 13};
    int n = sizeof(v) / sizeof(v[0]);

    cout << "Vetor antes da ordenacao: ";
    exibir(v, n);

    mergeSort(v, 0, n - 1);

    cout << "Vetor depois da ordenacao: ";
    exibir(v, n);

    return 0;
}