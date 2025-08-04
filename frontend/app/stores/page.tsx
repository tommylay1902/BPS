import React from "react";
import { Store } from "./_types/store";

import StoreManagement from "./_components/store-management";

const StorePage = async () => {
  const baseUrl = process.env.NEXT_PUBLIC_API_BASE_URL;
  const response = await fetch(`${baseUrl}/api/Store`);
  const stores: Store[] = await response.json();

  return <StoreManagement data={stores} />;
};

export default StorePage;
