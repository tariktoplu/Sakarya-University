#include "YoneticiListesi.h"
#include "SatirListesiDugum.h"
#include <cstddef>
#include <iostream>

using namespace std;

void YoneticiListesi::ekle(SatirListesi* sl) {
    SatirListesiDugum* sld = new SatirListesiDugum(sl);
    if (this->ilk == NULL) {
        this->ilk = sld;
        this->boyut = 1;
    } else {
        this->boyut++;

        float sl_ortalama = sl->ortalamayi_hesapla();
        SatirListesiDugum* tmp = this->ilk;

        if (this->ilk->sonraki == NULL) {
            if (this->ilk->sl->ortalamayi_hesapla() < sl_ortalama) {
                this->ilk->sonraki = sld;
                sld->onceki = this->ilk;
            } else {
                this->ilk->onceki = sld;
                sld->sonraki = this->ilk;
                this->ilk = sld;
            }
            return;
        }


        while(tmp->sonraki != NULL && tmp->sl->ortalamayi_hesapla() < sl_ortalama) {
            tmp = tmp->sonraki;
        }

        if (this->ilk == tmp) {
            sld->sonraki = this->ilk;
            this->ilk->onceki = sld;
            this->ilk = sld;
            return;
        } else if (tmp->sonraki == NULL) {
            if (tmp->sl->ortalamayi_hesapla() < sl_ortalama) {
                tmp->sonraki = sld;
                sld->onceki = tmp;
                return;
            }
        }

        sld->onceki = tmp->onceki;
        sld->onceki->sonraki = sld;
        sld->sonraki = tmp;
        tmp->onceki = sld;        
    }
}

void YoneticiListesi::sil(SatirListesiDugum* sld) {
    this->boyut--;
    if (this->ilk == sld) {
        this->ilk = this->ilk->sonraki;
        this->ilk->onceki = NULL;
    } else if (sld->sonraki == NULL) {
        sld->onceki->sonraki = NULL;
    } else {
        sld->onceki->sonraki = sld->sonraki;
        sld->sonraki->onceki = sld->onceki;
    }
}

SatirListesiDugum* YoneticiListesi::n_inci_dugum(int n) {
    SatirListesiDugum* tmp;
    tmp = this->ilk;
    for (int i = 1; i < n; i++) {
        tmp = tmp->sonraki;
    }
    return tmp;
    
}


void YoneticiListesi::goster() {
    SatirListesiDugum* tmp = this->ilk;
	while (tmp != NULL) {
        tmp->sl->goster();
		tmp = tmp->sonraki;
	}
}
