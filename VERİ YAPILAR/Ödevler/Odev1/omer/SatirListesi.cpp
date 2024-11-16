#include "SatirListesi.h"

#include <cstddef>
#include <iostream>
#include <cstdlib>

using namespace std;

SatirListesi::SatirListesi() {
	this->eleman_sayisi = 0;
	this->ilk = NULL;
}

float SatirListesi::ortalamayi_hesapla() {
	int sayac = 0;
	int toplam = 0;
	
	if (this->ilk == NULL) return 0;
	else {
		Dugum* tmp = this->ilk;
		while(tmp != NULL) {
			sayac++;
			toplam += tmp->deger;
			tmp = tmp->sonraki;
		}
	}
	float ortalama = (float) toplam / sayac;
	return ortalama;
}

void SatirListesi::ekle(int deger) {
	Dugum* dugum = new Dugum(deger);
	if (this->ilk == NULL) {
		this->ilk = dugum;
	} else {
		Dugum* tmp = this->ilk;
		while (tmp->sonraki != NULL) {
			tmp = tmp->sonraki;
		}
		tmp->sonraki = dugum;
		dugum->onceki = tmp;
	}
	this->eleman_sayisi++;
}

void SatirListesi::sil(Dugum *dugum) {
	if (dugum == this->ilk) {
		if (this->eleman_sayisi == 1) {
			this->ilk = NULL;
		} else {
			ilk = ilk->sonraki;
			ilk->onceki = NULL;
		}
	} else if (dugum->sonraki == NULL) {
		dugum->onceki->sonraki = NULL;
		dugum->onceki = NULL;
	} else {
		dugum->onceki->sonraki = dugum->sonraki;
		dugum->sonraki->onceki = dugum->onceki;
	}
	this->eleman_sayisi--;
}

void SatirListesi::goster() {
	Dugum* tmp = this->ilk;
    cout << "[ " << this->ortalamayi_hesapla() << " ] ";
	while (tmp != NULL) {
		cout << " " << tmp->deger;
		tmp = tmp->sonraki;
	}
    cout << endl;
}

Dugum* SatirListesi::rastgele_dugum_sec() {
	int rastgele_indis = rand() % this->eleman_sayisi;
	Dugum* tmp = this->ilk;
	for(int i = 0; i < rastgele_indis; i++) {
		tmp = tmp->sonraki;
	}
	return tmp;
};


