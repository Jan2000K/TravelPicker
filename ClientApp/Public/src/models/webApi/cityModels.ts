export enum Continents{
    Europe = 0,
    Africa = 1,
    NorthAmerica = 2,
    SouthAmerica = 3,
    Asia = 4,
    Australia = 5
}

export interface IRandomCityFilterVM{
    continents? : number[] | undefined
    countryCode? : string |undefined
}
