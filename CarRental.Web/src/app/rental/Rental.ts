import { Location } from '../location/Location';
import { Customer } from '../customer/Customer';
import { Car } from '../car/Car';

export class Rental {
    id: number;
    startDate: Date;
    endDate: Date;
    remarks: string;
    pickUpLocation: Location;
    pickUpLocationId: number;
    dropOffLocation: Location;
    dropOffLocationId: number;
    customer: Customer;
    customerId: number;
    car: Car;
    carId: number;
    reserved: boolean;
}
