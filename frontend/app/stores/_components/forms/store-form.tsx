"use client";
import React from "react";
import { useForm } from "react-hook-form";
import { storeSchema } from "../../_types/schemas/store-schema";
import z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";

const StoreForm = () => {
  function createStoreWithLocation(values: z.infer<typeof storeSchema>) {
    console.log(values);
  }
  const form = useForm<z.infer<typeof storeSchema>>({
    resolver: zodResolver(storeSchema),
    defaultValues: {
      name: "",
      location: {
        country: "",
        city: "",
        state: "",
        street: "",
        suite: null,
        zipCode: "",
      },
    },
  });
  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(createStoreWithLocation)}
        className="space-y-8"
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Name</FormLabel>
              <FormControl>
                <Input placeholder="shadcn" {...field} />
              </FormControl>
              <FormDescription>This is the name of the store</FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
};

export default StoreForm;
