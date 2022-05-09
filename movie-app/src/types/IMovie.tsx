export default interface IMovie {
  id: string;
  title: string;
  plot: string;
  genres?: Array<string>;
  released: string;
  year?: number;
}
