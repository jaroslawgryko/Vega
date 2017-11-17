export interface KeyValuePair {
    id: number;
    nazwa: string;
}

export interface Kontakt {
    nazwa: string;
    telefon: string;
    email: string;
}

export interface Pojazd {
    id: number;
    model: KeyValuePair;
    marka: KeyValuePair;
    czyZarejestrowany: boolean;
    atrybuty: KeyValuePair[];
    kontakt: Kontakt;
    ostatniaZmiana: string;
}

export interface SavePojazd {
    id: number;
    modelId: number;
    markaId: number;
    czyZarejestrowany: boolean;
    atrybuty: number[];
    kontakt: Kontakt;
}