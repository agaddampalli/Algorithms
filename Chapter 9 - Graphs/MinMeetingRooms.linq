<Query Kind="Program" />

void Main()
{
	var input = new int[][] { new int[] { 9, 10 }, new int[] { 4, 9 }, new int[] { 4, 17 } };
	//	var input = new int[][] { new int[] { 64738, 614406 }, new int[] { 211748, 780229 }, new int[] { 208641, 307338 }, new int[] { 499908, 869489 }, new int[] { 218907, 889449 }, new int[] { 177201, 481150 }, new int[] { 123679, 384415 }, new int[] { 120440, 404695 }, new int[] { 191810, 491295 }, new int[] { 800783, 826206 }, new int[] { 165175, 221995 }, new int[] { 420412, 799259 }, new int[] { 484168, 617671 }, new int[] { 746410, 886281 }, new int[] { 765198, 792311 }, new int[] { 493853, 971285 }, new int[] { 194579, 313372 }, new int[] { 119757, 766274 }, new int[] { 101315, 917883 }, new int[] { 557309, 599256 }, new int[] { 167729, 723580 }, new int[] { 731216, 988021 }, new int[] { 225883, 752657 }, new int[] { 588461, 854166 }, new int[] { 231328, 285640 }, new int[] { 772811, 869625 }, new int[] { 892212, 973218 }, new int[] { 143535, 306402 }, new int[] { 336799, 998119 }, new int[] { 65892, 767719 }, new int[] { 380440, 518918 }, new int[] { 321447, 558462 }, new int[] { 54489, 234291 }, new int[] { 43934, 44986 }, new int[] { 11260, 968186 }, new int[] { 248987, 707178 }, new int[] { 355162, 798511 }, new int[] { 661962, 781083 }, new int[] { 149228, 412762 }, new int[] { 71084, 953153 }, new int[] { 44890, 655659 }, new int[] { 708781, 956341 }, new int[] { 251847, 707658 }, new int[] { 650743, 932826 }, new int[] { 561965, 814428 }, new int[] { 697026, 932724 }, new int[] { 583473, 919161 }, new int[] { 463638, 951519 }, new int[] { 769086, 785893 }, new int[] { 17912, 923570 }, new int[] { 423089, 653531 }, new int[] { 317269, 395886 }, new int[] { 412117, 701471 }, new int[] { 465312, 520002 }, new int[] { 168739, 770178 }, new int[] { 624091, 814316 }, new int[] { 143729, 249836 }, new int[] { 699196, 879379 }, new int[] { 585322, 989087 }, new int[] { 501009, 949840 }, new int[] { 424092, 580498 }, new int[] { 282845, 345477 }, new int[] { 453883, 926476 }, new int[] { 392148, 878695 }, new int[] { 471772, 771547 }, new int[] { 339375, 590100 }, new int[] { 110499, 619323 }, new int[] { 8713, 291093 }, new int[] { 268241, 283247 }, new int[] { 160815, 621452 }, new int[] { 168922, 810532 }, new int[] { 355051, 377247 }, new int[] { 10461, 488835 }, new int[] { 220598, 261326 }, new int[] { 403537, 438947 }, new int[] { 221492, 640708 }, new int[] { 114702, 926457 }, new int[] { 166567, 477230 }, new int[] { 856127, 882961 }, new int[] { 218411, 256327 }, new int[] { 184364, 909088 }, new int[] { 130802, 828793 }, new int[] { 312028, 811716 }, new int[] { 294638, 839683 }, new int[] { 269329, 343517 }, new int[] { 167968, 391811 }, new int[] { 25351, 369583 }, new int[] { 210660, 454598 }, new int[] { 166834, 576380 }, new int[] { 296440, 873280 }, new int[] { 660142, 822072 }, new int[] { 33441, 778393 }, new int[] { 456500, 955635 }, new int[] { 59220, 954158 }, new int[] { 306295, 429913 }, new int[] { 110402, 448322 }, new int[] { 44523, 88192 }, new int[] { 231386, 353197 }, new int[] { 120940, 902781 }, new int[] { 348758, 597599 }, new int[] { 329467, 664450 }, new int[] { 208411, 890114 }, new int[] { 230238, 516885 }, new int[] { 434113, 602358 }, new int[] { 349759, 419831 }, new int[] { 10689, 308144 }, new int[] { 94526, 180723 }, new int[] { 435280, 986655 }, new int[] { 611999, 690154 }, new int[] { 75208, 395348 }, new int[] { 403243, 489260 }, new int[] { 498884, 611075 }, new int[] { 487209, 863242 }, new int[] { 13900, 873774 }, new int[] { 656706, 782943 }, new int[] { 53478, 586952 }, new int[] { 226216, 723114 }, new int[] { 554799, 922759 }, new int[] { 467777, 689913 }, new int[] { 80630, 147482 }, new int[] { 277803, 506346 }, new int[] { 532240, 976029 }, new int[] { 206622, 761192 }, new int[] { 148277, 985819 }, new int[] { 10879, 807349 }, new int[] { 952227, 971268 }, new int[] { 172074, 919866 }, new int[] { 239230, 384499 }, new int[] { 607687, 984661 }, new int[] { 4405, 264532 }, new int[] { 41071, 437502 }, new int[] { 432603, 661142 }, new int[] { 144398, 907360 }, new int[] { 139605, 360037 }, new int[] { 943191, 997317 }, new int[] { 12894, 171584 }, new int[] { 382477, 800157 }, new int[] { 452077, 518175 }, new int[] { 208007, 398880 }, new int[] { 375250, 489928 }, new int[] { 384503, 726837 }, new int[] { 278181, 628759 }, new int[] { 114470, 635575 }, new int[] { 382297, 733713 }, new int[] { 156559, 874172 }, new int[] { 507016, 815520 }, new int[] { 164461, 532215 }, new int[] { 17332, 536971 }, new int[] { 418721, 911117 }, new int[] { 11497, 14032}};

	MinMeetingRooms(input).Dump();

}

public int MinMeetingRooms(int[][] intervals)
{
	if (intervals.Length <= 1)
		return intervals.Length;

	int[] start = new int[intervals.Length];
	int[] end = new int[intervals.Length];
	for (int i = 0; i < intervals.Length; i++)
	{
		start[i] = intervals[i][0];
		end[i] = intervals[i][1];
	}

	Array.Sort(start);
	Array.Sort(end);

	int startPointer = 0, endPointer = 0;

	// Variables to keep track of maximum number of rooms used.
	int usedRooms = 0;

	// Iterate over intervals.
	while (startPointer < intervals.Length)
	{

		// If there is a meeting that has ended by the time the meeting at `start_pointer` starts
		if (start[startPointer] >= end[endPointer])
		{
			usedRooms -= 1;
			endPointer += 1;
		}

		// We do this irrespective of whether a room frees up or not.
		// If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
		// remain the same in that case. If no room was free, then this would increase used_rooms
		usedRooms += 1;
		startPointer += 1;

	}
	
	return usedRooms;
}