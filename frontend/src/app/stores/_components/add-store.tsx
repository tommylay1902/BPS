"use client";
import { StoreFieldName, storeSchema } from "@/app/stores/_schemas/storeSchema";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogTrigger,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
  DialogFooter,
  DialogClose,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  Form,
  FormControl,
  FormMessage,
  FormField,
  FormItem,
  FormLabel,
} from "@/components/ui/form";
import { getFieldsFromSchema } from "@/lib/getFieldsFromSchema";

export default function AddStore() {
  const storeFields = getFieldsFromSchema(storeSchema, {
    name: { colSpan: "col-span-4" },
    "location.country": { colSpan: "col-span-1" },
    "location.city": { colSpan: "col-span-2" },
    "location.state": { colSpan: "col-span-1" },
    "location.street": { colSpan: "col-span-1" },
    "location.zipCode": { colSpan: "col-span-1" },
    "location.suite": { colSpan: "col-span-1" },
  });
  const form = useForm<z.infer<typeof storeSchema>>({
    resolver: zodResolver(storeSchema),
    defaultValues: {
      name: "",
    },
  });

  const onSubmit = (data: z.infer<typeof storeSchema>) => console.log(data);

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="outline">Add Store</Button>
      </DialogTrigger>

      <DialogContent className="min-w-[80vw] min-h-[70vh]">
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="grid grid-cols-4 gap-3"
          >
            <DialogHeader className="col-span-4">
              <DialogTitle>Add Store</DialogTitle>
              <DialogDescription>
                Add Stores that you buy your groceries from
              </DialogDescription>
            </DialogHeader>

            {storeFields.map((field) => (
              <FormField
                key={field.name}
                control={form.control}
                name={field.name as StoreFieldName}
                render={({ field: formField }) => (
                  <FormItem className={field.colSpan}>
                    <FormLabel>
                      {field.label}
                      {field.optional && (
                        <span className="text-muted-foreground">
                          {" "}
                          (optional)
                        </span>
                      )}
                    </FormLabel>
                    <FormControl>
                      <Input
                        placeholder={field.placeholder}
                        value={formField.value as string}
                        onChange={formField.onChange}
                        onBlur={formField.onBlur}
                        ref={formField.ref}
                        type={field.type || "text"}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            ))}

            <DialogFooter className="mt-4 col-span-4">
              <DialogClose asChild>
                <Button variant="outline" type="button">
                  Cancel
                </Button>
              </DialogClose>
              <Button type="submit">Save changes</Button>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
}
