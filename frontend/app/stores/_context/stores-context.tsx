// stores-context.tsx
"use client";
import { createContext, useContext, useState } from "react";
import { Store } from "../_types/store";

interface StoresContextType {
  stores: Store[];
  addStore: (store: Store) => void;
  removeStore: (idList: string[]) => void;
  // Add other methods as needed
}

const StoresContext = createContext<StoresContextType | undefined>(undefined);

export const StoresProvider = ({
  children,
  initialData,
}: {
  children: React.ReactNode;
  initialData: Store[];
}) => {
  const [stores, setStores] = useState<Store[]>(initialData);

  const addStore = (store: Store) => {
    setStores((prev) => [...prev, store]);
  };

  const removeStore = (idList: string[]) => {
    setStores((stores) => stores.filter((store) => !idList.includes(store.id)));
  };

  return (
    <StoresContext.Provider value={{ stores, addStore, removeStore }}>
      {children}
    </StoresContext.Provider>
  );
};

export const useStores = () => {
  const context = useContext(StoresContext);
  if (context === undefined) {
    throw new Error("useStores must be used within a StoresProvider");
  }
  return context;
};
