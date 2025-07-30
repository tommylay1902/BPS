"use client";

import { Path } from "react-hook-form";
import { z } from "zod";

export const storeSchema = z.object({
  name: z.string().min(2).max(50),
  location: z.object({
    country: z.string().min(1),
    state: z.string().min(1),
    city: z.string().min(1),
    street: z.string().min(1),
    zipCode: z.string().min(1),
    suite: z.string().optional(),
  }),
});

export type StoreFormValues = z.infer<typeof storeSchema>;
export type StoreFieldName = Path<StoreFormValues>;
