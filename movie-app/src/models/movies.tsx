export type Movie = {
  id: string;
  title: string;
  plot: string;
  genres?: Array<string>;
  released: string;
  year?: number;
};
