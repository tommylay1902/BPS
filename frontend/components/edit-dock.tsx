import React from "react";
import { Button } from "./ui/button";
import { Trash } from "lucide-react";
export const EditDock = () => {
  return (
    <div className="fixed bottom-8 left-1/2 flex -translate-x-1/2 transform animate-float-up gap-4 rounded-full bg-slate-700 p-4">
      <div className="group relative">
        <Button
          variant="destructive"
          className="peer/delete rounded-full transition-all duration-300 hover:scale-110 group-hover/update:scale-90 [&_svg]:size-5"
        >
          <Trash />
        </Button>
      </div>
    </div>
  );
};

export default EditDock;
