import { z } from "zod";

type FieldConfig = {
  name: string;
  label: string;
  placeholder: string;
  type?: string;
  optional?: boolean;
  colSpan?:
    | "col-span-1"
    | "col-span-2"
    | "col-span-3"
    | "col-span-4"
    | "col-span-5"
    | "col-span-6"
    | "col-span-7"
    | "col-span-8"
    | "col-span-9"
    | "col-span-10"
    | "col-span-11"
    | "col-span-12";
};

type ZodObjectShape = Record<string, z.ZodTypeAny>;

type Paths<T> = T extends object
  ? {
      [K in keyof T]: K extends string
        ? T[K] extends object
          ? `${K}.${Paths<T[K]>}` | K
          : K
        : never;
    }[keyof T]
  : never;

type FieldConfigOptions<T> = Partial<
  Record<Paths<T>, { colSpan?: FieldConfig["colSpan"] }>
>;

export function getFieldsFromSchema<
  T extends ZodObjectShape,
  S extends z.ZodObject<T>,
>(schema: S, customConfig?: FieldConfigOptions<z.infer<S>>): FieldConfig[] {
  const shape = schema.shape;
  return Object.entries(shape).flatMap(([key, value]) => {
    if (value instanceof z.ZodObject) {
      return Object.entries(value.shape).map(([nestedKey, nestedValue]) => {
        const fullPath = `${key}.${nestedKey}`;
        return {
          name: fullPath,
          label: nestedKey.charAt(0).toUpperCase() + nestedKey.slice(1),
          placeholder: `Enter ${nestedKey}`,
          optional: nestedValue.isOptional(),
          colSpan:
            customConfig?.[fullPath as keyof FieldConfigOptions<z.infer<S>>]
              ?.colSpan || "col-span-3",
        };
      });
    }
    return {
      name: key,
      label: key.charAt(0).toUpperCase() + key.slice(1),
      placeholder: `Enter ${key}`,
      optional: value.isOptional(),
      colSpan:
        customConfig?.[key as keyof FieldConfigOptions<z.infer<S>>]?.colSpan ||
        "col-span-3",
    };
  });
}
