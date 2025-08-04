export const storeConfig = [
  {
    name: "name",
    label: "Name",
    description: "Store name",
    placeholder: "Albertsons",
    gridSpace: "col-span-4",
  },
  {
    name: "location.country",
    label: "Country",
    description: "Country",
    placeholder: "USA",
    gridSpace: "col-span-2",
  },
  {
    name: "location.state",
    label: "State",
    description: "State",
    placeholder: "CA",
    gridSpace: "col-span-2",
  },
  {
    name: "location.city",
    label: "City",
    description: "City",
    placeholder: "Santa Maria",
    gridSpace: "col-span-2",
  },

  {
    name: "location.street",
    label: "Street",
    description: "Street",
    placeholder: "123 Jane St.",
    gridSpace: "col-span-2",
  },
  {
    name: "location.zipCode",
    label: "Zip Code",
    description: "Zip Code",
    placeholder: "12345",
    gridSpace: "col-span-2",
  },
] as const;
