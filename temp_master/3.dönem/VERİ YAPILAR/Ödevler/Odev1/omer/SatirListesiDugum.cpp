#include "SatirListesiDugum.h"
#include "SatirListesi.h"
#include <cstddef>

SatirListesiDugum::SatirListesiDugum(SatirListesi* sl) {
    this->sl = sl;
    this->sonraki = NULL;
    this->onceki = NULL;
}