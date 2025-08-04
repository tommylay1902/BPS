import React from "react";
import { Store } from "./_types/store";

import StoreManagement from "./_components/store-management";
import { StoresProvider } from "./_context/stores-context";

const StorePage = async () => {
  const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL;
  const response = await fetch(`${baseUrl}/api/Store`);
  const stores: Store[] = await response.json();

  return (
    <StoresProvider initialData={stores}>
      <StoreManagement />
    </StoresProvider>
  );
};

export default StorePage;
