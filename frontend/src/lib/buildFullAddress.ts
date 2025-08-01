import { StoreLocation } from "@/app/stores/_types/location";
export const buildFullAddress = (location: StoreLocation) => {
  if (location.suite) {
    return `${location?.city}, ${location?.street} ${location?.suite}, ${location?.zipCode}`;
  }
  return `${location?.city}, ${location?.street}, ${location?.zipCode}`;
};
