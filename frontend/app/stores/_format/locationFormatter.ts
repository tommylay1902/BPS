import { Location } from "../_types/location";

export const locationFormatterToString = (location: Location) => {
  return location.suite == null
    ? `${location.country}, ${location.state}, ${location.city}, ${location.street}, ${location.zipCode}`
    : `${location.country}, ${location.state}, ${location.city}, ${location.street} ${location.suite}, ${location.zipCode}`;
};
