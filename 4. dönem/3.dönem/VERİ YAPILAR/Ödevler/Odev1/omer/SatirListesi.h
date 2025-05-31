#ifndef SATIRLISTESI_H
#define SATIRLISTESI_H
#include "Dugum.h"

class SatirListesi
{
	public:
		Dugum* ilk;
		int eleman_sayisi;
		SatirListesi();
		float ortalamayi_hesapla();
		void ekle(int);
		void sil(Dugum*);
		void goster();
		Dugum* rastgele_dugum_sec();
};

#endif
