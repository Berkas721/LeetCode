export interface IProblem {
  id: number
  name: string,
  description: string,
  difficulty: number,
  status: number,
  creatorId: string,
  createdAt: string,
  updaterId: string,
  updatedAt: string,
  openerId: string,
  openedAt: string
}