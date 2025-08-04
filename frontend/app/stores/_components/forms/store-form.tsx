"use client";
import React from "react";
import { useForm } from "react-hook-form";
import { storeSchema } from "@/app/stores/_types/form-config/schemas/store-schema";
import z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { storeConfig } from "../../_types/form-config/schemas/store-config";
interface StoreFormProps {
  handleCloseDialog: (state: boolean) => void;
}
const StoreForm: React.FC<StoreFormProps> = ({ handleCloseDialog }) => {
  async function createStoreWithLocation(values: z.infer<typeof storeSchema>) {
    const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL;
    try {
      const response = await fetch(baseUrl + "/api/Store/with-location", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(values),
      });

      if (response.status == 201) {
        handleCloseDialog(false);
      }
    } catch (e) {
      console.error(e);
    }
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
        className="space-y-8 grid grid-cols-4 space-x-4"
      >
        {storeConfig.map((config, index) => (
          <FormField
            key={index}
            control={form.control}
            name={config.name}
            render={({ field }) => (
              <FormItem className={config.gridSpace}>
                <FormLabel>{config.label}</FormLabel>
                <FormControl>
                  <Input placeholder={config.placeholder} {...field} />
                </FormControl>
                {/*<FormDescription>{config.description}</FormDescription>*/}
                <FormMessage />
              </FormItem>
            )}
          />
        ))}

        <Button type="submit" className="col-span-4">
          Add Store
        </Button>
      </form>
    </Form>
  );
};

export default StoreForm;
