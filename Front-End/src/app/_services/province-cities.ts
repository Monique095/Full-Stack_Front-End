import { Injectable } from '@angular/core';
import { Provinces } from '../_models/provinces';
import { City } from '../_models/cities';

@Injectable()
export class SelectService {

    getProvinces() {
        return [
         new Provinces(1, 'Free State' ),
         new Provinces(2, 'Gauteng' ),
         new Provinces(3, 'Western Cape' ),
         new Provinces(4, 'KwaZulu Natal' ),
         new Provinces(5, 'Mpumalanga' ),
         new Provinces(6, 'Eastern Cape' ),
         new Provinces(7, 'North West' ),
         new Provinces(8, 'Limpopo' ),
         new Provinces(9, 'Northern Cape' ),
        ];
      }

      getCities() {
        return [
          new City(1,'Free State','Bloemfontein' ),
          new City(2,'Free State','Bethlehem' ),
          new City(3,'Free State','Clarens'),
          new City(4,'Free State','Fouriesburg'),
          new City(5,'Free State','Welkom' ),
          new City(6,'Free State','Virginia'),
          new City(8,'Free State','Deneysville'),
          new City(9,'Free State','Vredefort'),
          new City(10,'Free State','Sasolburg'),
          new City(11,'Free State','Odendaalsrus'),
          new City(12,'Free State','Ficksburg'),
          new City(13,'Free State','Bethulie'),
          new City(14,'Free State','Parys'),
          new City(15,'Free State','Harrismith'),
          new City(16,'Free State','Ladybrand'),
          new City(17,'Gauteng','Pretoria'),
          new City(18,'Gauteng','Johannesburg'),
          new City(19,'Western Cape','Cape Town'),
          new City(20,'Western Cape','Somerset West'),
          new City(21,'KwaZulu Natal','Durban'),
          new City(22,'KwaZulu Natal','Pietermaritzburg'),
          new City(23,'Mpumalanga','Nelspruit'),
          new City(24,'Mpumalanga','Witbank'),
          new City(25,'Eastern Cape','Port Elizabeth'),
          new City(26,'Eastern Cape','East London'),
          new City(27,'North West','Rustenburg'),
          new City(28,'North West','Potchefstroom'),
          new City(29,'Limpopo','Polokwane'),
          new City(30,'Limpopo','Tzaneen'),
          new City(31,'Northern Cape','Port Nolloth'),
          new City(32,'Northern Cape','Kimberley'),
         ];
        }


    }