import { StoreLocation } from "./location";

export interface Store {
  id: string;
  name: string;
  locationId: string;
  location?: StoreLocation;
}
