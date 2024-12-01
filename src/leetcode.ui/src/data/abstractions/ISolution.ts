export interface ISolution {
  id: number;
  implementedProblemId: string;
  code: string;
  createInfo: {
    date: string;
    agentId: string;
  };
  status: number;
  updatedAt: string | null;
  submittedAt: string | null;
  totalUsedTime: number | null;
  totalUsedMemory: number | null;
  failedTestIds: number[] | null;
}
