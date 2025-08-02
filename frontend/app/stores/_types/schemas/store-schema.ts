import z from "zod";
export const storeSchema = z.object({
  name: z.string().min(1, {
    message: "store name is required!",
  }),
  location: z.object({
    country: z.string().min(1, {
      message: "country is required!",
    }),
    city: z.string().min(1, {
      message: "city is required!",
    }),
    state: z.string().min(1, {
      message: "state is required!",
    }),
    street: z.string().min(1, {
      message: "street is required!",
    }),
    suite: z.string().nullable(),
    zipCode: z.string().min(1, {
      message: "zipCode is required!",
    }),
  }),
});
