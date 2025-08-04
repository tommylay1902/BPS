import z from "zod";
export const storeSchema = z.object({
  name: z.string().min(1, {
    message: "Store name is required!",
  }),
  location: z.object({
    country: z.string().min(1, {
      message: "Country is required!",
    }),
    city: z.string().min(1, {
      message: "City is required!",
    }),
    state: z.string().min(1, {
      message: "State is required!",
    }),
    street: z.string().min(1, {
      message: "Street is required!",
    }),
    suite: z.string().nullable(),
    zipCode: z.string().min(1, {
      message: "ZipCode is required!",
    }),
  }),
});
